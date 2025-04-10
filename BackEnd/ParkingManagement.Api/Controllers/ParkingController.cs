using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Api.Healpers;
using ParkingManagement.Core.DTOS;
using ParkingManagement.Core.Entities;
using ParkingManagement.Core.Interfaces;
using ParkingManagement.Services;

namespace ParkingManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IFileUpload _fileUpload;
        private readonly IParkingService _parkingService;

        public ParkingController(IFileUpload fileUpload, IParkingService parkingService)
        {
            this._fileUpload = fileUpload;
            this._parkingService = parkingService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllParkings()
        {
            var parkings = await _parkingService.GetAllParkings();
            return Ok(parkings);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParkingById(int id)
        {
            var parking = await _parkingService.GetParkingById(id);

            if (parking == null)
            {
                return BadRequest();
            }

            return Ok(parking);
        }


        [Authorize(Roles = ("Admin"))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParking(int id)
        {
            var parking = await _parkingService.GetParkingById(id);
            if (parking is null)
            {
                return NotFound();
            }

            await _parkingService.DeleteParking(parking);
            _fileUpload.DeleteImage(parking.Picture, "Uploads/ParkingsImages");
            return NoContent();
        }



        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<IActionResult> AddParking(AddParkingDTO newParking)
        {
            if (ModelState.IsValid)
            {
                if (newParking.Days == null || newParking.Days.Length != 7)
                {
                    return BadRequest("Days must contain exactly 7 boolean values.");
                }

                _fileUpload.UploadImage(newParking.Picture, "Uploads/ParkingsImages");

                if (!_fileUpload.uploadState.State)
                {
                    return BadRequest(new { message = _fileUpload.uploadState.Message });
                }

                Parking parking = await _parkingService.AddParking(newParking, _fileUpload.uploadState.PhotoName);
                return CreatedAtAction(nameof(GetParkingById), new { id = parking.Id }, parking);
            }
            else
            {
                return ValidationProblem();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateParking(UpdateParkingDTO newParking)
        {
            if (ModelState.IsValid)
            {
                if (newParking.Days == null || newParking.Days.Length != 7)
                {
                    return BadRequest("Days must contain exactly 7 boolean values.");
                }

                Parking oldParking = await _parkingService.GetParkingById(newParking.Id);

                if (oldParking is null)
                {
                    return NotFound();
                }


                _fileUpload.UploadImage(newParking.Picture, "Uploads/ParkingsImages");

                if (!_fileUpload.uploadState.State)
                {
                    return BadRequest(new { message = _fileUpload.uploadState.Message });
                }

                _fileUpload.DeleteImage(oldParking.Picture, "Uploads/ParkingsImages");
                Parking parking = await _parkingService.UpdateParking(newParking, _fileUpload.uploadState.PhotoName);
                return NoContent();
            }
            else
            {
                return ValidationProblem();
            }
        }



        //private bool ParkingExists(int id)
        //{
        //    return _context.parkings.Any(e => e.Id == id);
        //}

        //[HttpGet("top")]
        //public async Task<IActionResult> GetTopParkings([FromQuery] int top = 6)
        //{
        //    var topParkings = await _context.parkings
        //        .Include(p => p.artisanClientServices)
        //        .Include(p => p.lots)
        //        .Include(p => p.Jours)
        //        .OrderByDescending(p => p.artisanClientServices.Count)
        //        .Take(top)
        //        .ToListAsync();

        //    return Ok(topParkings);
        //}

        //[HttpGet("image")]
        //public IActionResult GetImage()
        //{
        //    IList<Photo> photos = _context.photos.ToList();
        //    return Ok(photos);
        //}
    }
}
