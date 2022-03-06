using Arageek.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models
{
    public class Art : Audit
    {
        public List<Watch> Watch { get; set; }
        public List<Reviews> Reviews { get; set; }
        public List<InspirationalArtCharacter> InspirationalArtCharacters { get; set; }
        public List<OnNetflix> OnNetflix { get; set; }
    }

    public class Watch : Audit
    {
        public string Videos { get; set; }
    }


public class Reviews : Audit
{
    public string Review { get; set; }
}

public class InspirationalArtCharacter
{
    public string Categories { get; set; }
    public int CharactersId { get; set; }
}

public class OnNetflix
{
    public string Videos { get; set; }
}
}
