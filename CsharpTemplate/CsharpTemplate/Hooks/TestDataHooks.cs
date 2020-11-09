using CsharpTemplate.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CsharpTemplate.Hooks
{
    [Binding]
    public class TestDataHooks
    {
        private readonly ScenarioContext _context;




        public TestDataHooks(EnvironmentConfiguration envconfig, ScenarioContext context)
        {
            _context = context;
        }



        //[BeforeScenario("switchRejecctOrder", Order = -1)]
        //public async Task PushSwitchUnitOrder()
        //{
        //    var (submit, reject) = _switchOrderRepository.CreateRejectedOrder("Units", "isin");
        //    _context.TryAdd("orderSubmit", submit);
        //    _context.TryAdd("orderReject", reject);
        //}

    } }

