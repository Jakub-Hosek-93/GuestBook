using GuestBookAPI.Models;
using GuestBookAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace GuestBookAPI.Controllers;

[ApiController]
[Route("")]
public class GuestBookController : Controller
{
    private readonly GuestBookContext _context;
    
    public GuestBookController(GuestBookContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public List<RecordModel> ShowGuestBookEntries()
    {
        return _context.records.ToList();
    }   
    
    [HttpPost]
    public RecordModel AddRecord(RecordModel record)
    {
        record.Date = DateTime.Now;
        
        _context.records.Add(record);
        _context.SaveChanges();

        return record;
    }
}