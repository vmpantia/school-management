﻿using SM.Api.Models.Requests;

namespace SM.Api.Contractors
{
    public interface IStudentService
    {
        Task SaveStudent(SaveStudentRequest request);
    }
}