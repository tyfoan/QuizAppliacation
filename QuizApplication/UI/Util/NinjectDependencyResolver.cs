﻿using BLL.Interfaces;
using BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UI.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<IBaseQuizService>().To<QuizService>();
            _kernel.Bind<IAccountService>().To<AccountService>();
            _kernel.Bind<ITestService>().To<TestService>();
            _kernel.Bind<ISubjectService>().To<SubjectService>();
            _kernel.Bind<IQuestionService>().To<QuestionService>();
            _kernel.Bind<IAnswerService>().To<AnswerService>();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}