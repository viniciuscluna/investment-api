﻿using Investment.App.Api.Models;
using Investment.App.Api.ViewModels.Customer;

namespace Investment.App.Api;

public interface IOperationService
{
    Task<OperationResult> BuyAsync(BuyRequestViewModel request);
    Task<OperationResult> SellAsync(SellRequestViewModel request);
}
