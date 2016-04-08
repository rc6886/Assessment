using System.Linq;
using System.Web.Mvc;
using Assessment.Domain.Ohm;
using Assessment.Domain.Resistor;
using Assessment.Domain.Resistor.Repository;
using Assessment.Web.Extensions;
using Assessment.Web.Models;

namespace Assessment.Web.Controllers
{
    public class OhmValueCalculatorController : Controller
    {
        private readonly IOhmValueCalculator _ohmValueCalculator;
        private readonly IResistorColorCodeRepository _resistorColorCodeRepository;

        // Using Poor Man's DI given the scope of the project, but would refactor to using a IoC container if/when
        // the application increased in size/complexity.
        public OhmValueCalculatorController() : 
            this(new OhmValueCalculator(new ResistorColorCodeRepository()), new ResistorColorCodeRepository())
        {
        }

        public OhmValueCalculatorController(IOhmValueCalculator ohmValueCalculator, IResistorColorCodeRepository resistorColorCodeRepository)
        {
            _ohmValueCalculator = ohmValueCalculator;
            _resistorColorCodeRepository = resistorColorCodeRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDropdownValues()
        {
            var digitValues = _resistorColorCodeRepository.GetAllResistorColorCodesWithNonNullDigit().Select(x => x.ResistorColor.ToString());
            var multiplierValues = _resistorColorCodeRepository.GetAllResistorColorCodesWithNonNullMultiplier().Select(x => x.ResistorColor.ToString());
            var toleranceValues = _resistorColorCodeRepository.GetAllResistorColorCodesWithNonNullTolerance().Select(x => x.ResistorColor.ToString());

            var dropdownViewModel = new ResistorDropdownViewModel
            {
                BandAValues = digitValues,
                BandBValues = digitValues,
                BandCValues = multiplierValues,
                BandDValues = toleranceValues
            };

            return Json(dropdownViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Calculate(OhmValueCalculatorPostModel postModel)
        {
            var ohmValue = _ohmValueCalculator.CalculateOhmValues(postModel.ColorBandA, postModel.ColorBandB,
                postModel.ColorBandC, postModel.ColorBandD);

            var tolerance = _resistorColorCodeRepository
                .FindBy(ResistorColorCode.ParseResistorColor(postModel.ColorBandD))
                .Tolerance;

            return Json(new OhmValueCalculatorResponseModel
            {
                OhmValue = ohmValue.ToFormattedString(),
                Tolerance = tolerance?.ToString("P")
            });
        }
    }
}