﻿using HR_SurveyApp.Domain.Entities;
using HR_SurveyApp.Domain.RepositoryContracts;
using HR_SurveyApp.Infrastructure.DatabaseContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_SurveyApp.Infrastructure.Repositories
{
    public class SurveyRepository(ApplicationDbContext db) : Repository<Survey>(db), ISurveyRepository
    {

    }
}
