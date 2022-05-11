using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GJJP8B_HFT_2021221.Endpoint
{
    [Route("[controller]/[action]")]
    public class NonCrudController : ControllerBase
    {
        IBuyerLogic buyerLogic;
    }
}
