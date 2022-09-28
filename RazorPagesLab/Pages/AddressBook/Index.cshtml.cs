using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook;

public class IndexModel : PageModel
{
	private readonly IRepo<AddressBookEntry> _repo;

    public IEnumerable<AddressBookEntry> AddressBookEntries;

	public IndexModel(IRepo<AddressBookEntry> repo)
    {
        _repo = repo;
    }

    public void OnGet()
	{
		AddressBookEntries = _repo.Find(new AllEntriesSpecification());
	}
    
}