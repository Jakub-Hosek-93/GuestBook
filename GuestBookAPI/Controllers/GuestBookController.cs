using GuestBookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuestBookAPI.Controllers;

[ApiController]
[Route("")]
public class GuestBookController : Controller
{
    // Database
    private static List<RecordModel> _guestBookEntries = new()
    {
        new RecordModel { ID = 1, Name = "Systém", Text = "Vítejte v naší knize vzkazů!", Date =  new DateTime(2021, 05, 01) },
        new RecordModel { ID = 2, Name = "Admin", Text = "Tohle je testovací zpráva.", Date = new DateTime(2021, 09, 01) },
    };
    
    [HttpGet]
    public List<RecordModel> ShowGuestBookEntries()
    {
        return _guestBookEntries;
    }   
    
    [HttpPost]
    public RecordModel AddRecord(RecordModel record)
    {
        record.ID = _guestBookEntries.Count + 1;
        record.Date = DateTime.Now;
        
        _guestBookEntries.Add(record);

        return record;

    }
}