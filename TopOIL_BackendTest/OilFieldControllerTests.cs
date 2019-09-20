using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopOIL_Backend;
using TopOIL_Backend.Controllers;
using TopOIL_Backend.Models;

namespace TopOIL_BackendTest
{
    [TestClass]
    public class OilFieldControllerTests
    {
        [TestMethod]
        public void GetListOnPage()
        {
            DbContextOptions<Context> options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "on_page")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (Context context = new Context(options))
            {
                context.OilFields.Add(new OilField
                    { ID = 1, Location = "test1", Name = "test1", NumOfEmployees = 0, NumOfPumpjacks = 1, Production = 5 });
                context.OilFields.Add(new OilField
                    { ID = 2, Location = "test2", Name = "test21", NumOfEmployees = 2, NumOfPumpjacks = 2, Production = 5 });
                context.OilFields.Add(new OilField
                    { ID = 3, Location = "test3", Name = "test3", NumOfEmployees = 444, NumOfPumpjacks = 444, Production = 444 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (Context context = new Context(options))
            {
                OilFieldController service = new OilFieldController(context);
                IActionResult result = service.Get("2", null).Result;
                OkObjectResult res = result as OkObjectResult;
                Assert.AreEqual(200, res.StatusCode);
                Assert.IsNotNull(res.Value);
            }
        }
        [TestMethod]
        public void DataNotFound()
        {
            DbContextOptions<Context> options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "not_fount")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (Context context = new Context(options))
            {
                context.OilFields.Add(new OilField
                    { ID = 1, Location = "test1", Name = "test1", NumOfEmployees = 0, NumOfPumpjacks = 1, Production = 5});
                context.OilFields.Add(new OilField
                    { ID = 2, Location = "test2", Name = "test21", NumOfEmployees = 2, NumOfPumpjacks = 2, Production = 5 });
                context.OilFields.Add(new OilField
                    { ID = 3, Location = "test3", Name = "test3", NumOfEmployees = 444, NumOfPumpjacks = 444, Production = 444 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (Context context = new Context(options))
            {
                OilFieldController service = new OilFieldController(context);

                IActionResult result = service.Get(66);
                NotFoundResult res = result as NotFoundResult;
                Assert.AreEqual(404, res.StatusCode);
            }
        }
        [TestMethod]
        public void DeleteData()
        {
            DbContextOptions<Context> options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "del")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (Context context = new Context(options))
            {
                context.OilFields.Add(new OilField
                { ID = 1, Location = "test1", Name = "test1", NumOfEmployees = 0, NumOfPumpjacks = 1, Production = 5 });
                context.OilFields.Add(new OilField
                { ID = 2, Location = "test2", Name = "test21", NumOfEmployees = 2, NumOfPumpjacks = 2, Production = 5 });
                context.OilFields.Add(new OilField
                { ID = 3, Location = "test3", Name = "test3", NumOfEmployees = 444, NumOfPumpjacks = 444, Production = 444 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (Context context = new Context(options))
            {
                OilFieldController service = new OilFieldController(context);

                IActionResult result = service.Delete(3);
                OkObjectResult res = result as OkObjectResult;
                Assert.AreEqual(200, res.StatusCode);
                Assert.IsTrue((bool)res.Value);

                result = service.Get(3);
                NotFoundResult resNo = result as NotFoundResult;
                Assert.AreEqual(404, resNo.StatusCode);
            }
        }
        [TestMethod]
        public void CreateData()
        {
            DbContextOptions<Context> options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "post")
                .Options;

            using (Context context = new Context(options))
            {
                OilFieldController service = new OilFieldController(context);

                IActionResult result = service.Get(1);
                NotFoundResult resNo = result as NotFoundResult;
                Assert.AreEqual(404, resNo.StatusCode);

                result = service.Post( new OilField
                { Location = "test1", Name = "test1", NumOfEmployees = 0, NumOfPumpjacks = 1, Production = 5 });

                OkObjectResult res = result as OkObjectResult;
                Assert.AreEqual(200, res.StatusCode);
                OilField val = (OilField)res.Value;
                Assert.AreEqual(1 , val.ID);

            }
        }
        [TestMethod]
        public void UpdateData()
        {
            DbContextOptions<Context> options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "put")
                .Options;

            using (Context context = new Context(options))
            {
                context.OilFields.Add(new OilField
                { ID = 1, Location = "test1", Name = "test1", NumOfEmployees = 0, NumOfPumpjacks = 1, Production = 5 });

                context.SaveChanges();
            }

            using (Context context = new Context(options))
            {
                OilFieldController service = new OilFieldController(context);

                IActionResult result = service.Put(1, new OilField
                {ID = 1, Location = "test2", Name = "test2", NumOfEmployees = 0, NumOfPumpjacks = 1, Production = 5 });
                context.SaveChanges();

                OkObjectResult res = result as OkObjectResult;
                Assert.AreEqual(200, res.StatusCode);

                result = service.Get(1);
                res = result as OkObjectResult;
                Assert.AreEqual(200, res.StatusCode);
                OilField val = (OilField)res.Value;
                Assert.AreEqual("test2", val.Name);
            }
        }
    }
}
