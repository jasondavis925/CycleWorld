using CycleWorld.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CycleWorld.WebAPI.Controllers
{
    public class TransactionController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // POST (create)
        // api/Transaction
        [HttpPost]
        public async Task<IHttpActionResult> CreateTransaction([FromBody] Transaction model)
        {
            // Check if model is null
            if (model is null)
                return BadRequest("Your request body cannot be empty.");

            // Check validity of ModelState
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check the product exist and is in stock
            var part = await _context.Parts.FindAsync(model.PartId);
            if (part is null)
                return BadRequest($"The product with SKU of {model.PartId} does not exist.");

            if (part.IsInStock is false)
                return BadRequest($"{part.PartName} is out of stock.");

            // Check if enough inventory exist to complete transaction
            var transaction = await _context.Transactions.FindAsync(model.TransactionId);

            int numberInInventory = part.NumberInInventory;
            if (numberInInventory < model.ItemCount)
            {
                return base.BadRequest($"Only {numberInInventory} left in stock.");
            }

            // Remove purchased items from inventory
            _ = numberInInventory - model.ItemCount;

            // Add to the Transaction Entity

            _context.Transactions.Add(transaction);
            transaction.Part.NumberInInventory -= transaction.ItemCount;

            return await _context.SaveChangesAsync() == 1
                ? Ok($"You successfully purchased {part.PartName}!")
                : (IHttpActionResult)InternalServerError();
        }

        // GET ALL
        // api/Transaction
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Transaction> transactions = await _context.Transactions.ToListAsync();
            return Ok(transactions);
        }

        // GET BY ID
        // api/Transaction/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Transaction transaction = await _context.Transactions.FindAsync(id);

            if (transaction != null)
            {
                return Ok(transaction);
            }

            return NotFound();
        }

        // PUT (update)
        // api/Transaction/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateTransaction([FromUri] int id, [FromBody] Transaction updatedTransaction)
        {
            // Check the ids if they match
            if (id != updatedTransaction.TransactionId)
            {
                return BadRequest("Ids do not match.");
            }

            // Check the ModelIsState
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find the transaction in the database
            var transaction = await _context.Transactions.FindAsync(id);

            // If the transaction does not exist then do something
            if (transaction is null)
                return NotFound();

            // Update properties
            transaction.ItemCount = updatedTransaction.ItemCount;
            transaction.DateOfTransaction = updatedTransaction.DateOfTransaction;

            // Verify Product Change and Remove purchased items from inventory
            var part = await _context.Parts.FindAsync(updatedTransaction.PartId);

            part.NumberInInventory -= updatedTransaction.ItemCount;

            // Save the changes
            await _context.SaveChangesAsync();

            return Ok("The transaction was updated!");
        }

        // DELETE (delete)
        // api/Transaction/{id}
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTransaction([FromUriAttribute] int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction is null)
                return NotFound();

            // Add purchased item back into inventory
            var part = await _context.Parts.FindAsync(transaction.PartId);
            part.NumberInInventory -= transaction.ItemCount;

            //_context.Transactions.Remove(transaction);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The transaction was deleted.");
            }

            return InternalServerError();

            //Task<IHttpActionResult> Delete(int id)
            //{
            //    var userId = Int32.Parse(User.Identity.GetUserId());
            //    UserTest userTest = await db.

            //    db.SaveChangesAsync()
            //    await _context.savechangesasync() = 2, or _context.savechangesasync() > 0
            // }

        }
    }
}
