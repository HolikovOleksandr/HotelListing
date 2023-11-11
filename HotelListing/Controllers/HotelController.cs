using AutoMapper;
using HotelListing.Models;
using HotelListing.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers;

[Controller]
[Route("api/[controller]")]
public class HotelController : Controller
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<HotelController> _logger;
    public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetHotels()
    {
        try
        {
            var hotels = await _unitOfWork.Hotels.GetAll();
            var results = _mapper.Map<IList<HotelDTO>>(hotels);
            return Ok(results);
        }
        catch (Exception exeption)
        {
            _logger.LogError(exeption, $"Something went wrong in {nameof(GetHotels)}");
            return StatusCode(500, "Internal Server Error");
            throw;
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetHotel(int id)
    {
        try
        {
            var hotel = await _unitOfWork.Hotels.Get(h => h.Id == id, new List<string> { "Country" });
            var result = _mapper.Map<HotelDTO>(hotel);
            return Ok(result);
        }
        catch (Exception exeption)
        {
            _logger.LogError(exeption, $"Something went wrong in {nameof(GetHotel)}");
            return StatusCode(500, "Internal Server Error");
            throw;
        }
    }
}
