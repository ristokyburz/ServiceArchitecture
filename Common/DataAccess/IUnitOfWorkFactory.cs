﻿namespace Common.DataAccess
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork UnitOfWork();
    }
}