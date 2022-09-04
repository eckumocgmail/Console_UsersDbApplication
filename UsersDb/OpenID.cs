using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class OpenID : IValidatableObject, IEquatable<byte[]>, IEquatable<OpenID>
{
    public int ID { get; set; }

    [Required]
    public byte[] PublicKey { get; set; }

    [Required]
  
    public byte[] PrivateKey { get; set; }

    public bool Equals(byte[] other)
    {
        return false;
    }

    public bool Equals(OpenID other)
    {
        if (IsValide())
        {
            if (other.IsValide())
            {
                //TODO:
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (other.IsValide() == false)
            {
                if (PublicKey == null && other.PublicKey != null)
                    return false;
                if (PrivateKey == null && other.PrivateKey != null)
                    return false;
                if (PublicKey != null && other.PublicKey == null)
                    return false;
                if (PrivateKey != null && other.PrivateKey == null)
                    return false;
                if (PrivateKey.Length != other.PrivateKey.Length)
                    return false;
                if (PublicKey.Length != other.PublicKey.Length)
                    return false;
                return true;
            }
            else
            {
                return false;
            }
        }        

    }

    private bool IsValide()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }
}