using MVC_homework1.Models;
using MVC_homework1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_homework1.Service
{
    public class ClassifyService
    {
        private readonly IRepository<Classify> _classifyRepository;
        public ClassifyService(IUnitOfWork unitOfWork)
        {
            _classifyRepository = new Repository<Classify>(unitOfWork);
        }


        public List<SelectListItem> getOptionToSelectList(string kind)
        {
            var OptionList = _classifyRepository.LookupAll().Where(c=>c.Kind == kind).Select(c =>
                                  new SelectListItem()
                                  {
                                      Text = c.Desc,
                                      Value = c.Value.ToString()

                                  }).ToList();
            return OptionList;

        }

    }
}