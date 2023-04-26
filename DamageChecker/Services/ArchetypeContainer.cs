using DamageChecker.Pages;

namespace DamageChecker.Services
{
	public class ArchetypeContainer
	{
		private List<ArchetypeDamageChecker> _pages;
		public ArchetypeContainer() 
		{ 
			_pages = new List<ArchetypeDamageChecker>();
		}

		public void AddPage(ArchetypeDamageChecker page)
		{
			_pages.Add(page);
		}

		public IEnumerable<ArchetypeDamageChecker> GetPages()
		{
			return _pages;
		}
	}
}
