﻿namespace AddressBookEL.ResultModels
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; set; }
    }
}
