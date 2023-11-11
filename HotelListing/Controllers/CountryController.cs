using AutoMapper;
using HotelListing.Models;
using HotelListing.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers;

[Controller]
[Route("api/[controller]")]
public class CountryController : Controller
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CountryController> _logger;
    public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCountries()
    {
        try
        {
            var countries = await _unitOfWork.Countries.GetAll();
            var results = _mapper.Map<IList<CountryDTO>>(countries);
            return Ok(results);
        }
        catch (Exception exeption)
        {
            _logger.LogError(exeption, $"Something went wrong in the {nameof(GetCountries)}");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCountry(int id)
    {
        try
        {
            var country = await _unitOfWork.Countries.Get(c => c.Id == id, new List<string> { "Hotels" });
            var result = _mapper.Map<CountryDTO>(country);
            return Ok(result);
        }
        catch (Exception exeption)
        {
            _logger.LogError(exeption, $"Something went wrong in the {nameof(GetCountry)}");
            return StatusCode(500, "Internal Server Error");
        }

    }
}
