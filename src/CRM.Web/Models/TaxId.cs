using System;

namespace CRM.Web.Models
{
  public class TaxId
  {
    protected bool Equals(TaxId other)
    {
      return string.Equals(_taxId, other._taxId);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((TaxId) obj);
    }

    public override int GetHashCode()
    {
      return (_taxId != null ? _taxId.GetHashCode() : 0);
    }

    private readonly string _taxId;

    public TaxId(string taxId)
    {
      if (!IsValid(taxId))
      {
        throw new ArgumentException("Invalid TaxId");
      }
      _taxId = taxId;
    }

    public static bool IsValid(string taxId)
    {
      long result;
      if (taxId.Length != 11 || !long.TryParse(taxId, out result))
      {
        return false;
      }
      return true;
    }

    public override string ToString()
    {
      return _taxId;
    }

    public static bool operator ==(TaxId a, TaxId b)
    {
      return Equals(a,b);
    }

    public static bool operator !=(TaxId a, TaxId b)
    {
      return !(a == b);
    }

    public static bool operator ==(string a, TaxId b)
    {
      if (b == null)
      {
        return false;
      }
      return Equals(a, b._taxId);
    }

    public static bool operator !=(string a, TaxId b)
    {
      return !(a == b);
    }
  }
}