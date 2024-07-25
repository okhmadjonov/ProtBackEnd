﻿using Microsoft.AspNetCore.Mvc;
using Prot.Domain.Models.Response;

namespace Prot.Service.Extentions;



public class ResponseHandler
{
    public static ActionResult<T> ReturnActionResponse<T>(T model)
    {
        return new OkObjectResult(new ResponseModel<T>() { Status = true, Data = model });
    }

    public static IActionResult ReturnIActionResponse<T>(T model)
    {
        return new OkObjectResult(new ResponseModel<T>() { Status = true, Data = model });
    }

    public static IActionResult ReturnResponseList<T>(IEnumerable<T> model)
    {
        return new OkObjectResult(
            new ResponseModel<IEnumerable<T>>() { Status = true, Data = model }
        );
    }
}
