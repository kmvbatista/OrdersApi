using System;
using System.Linq;

namespace Domain.Validators.DocumentValidators
{
  public class CnpjValidator
  {
    private string Cnpj;
    private int[] firstValidationDigitWeights = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
    private int[] secondValidationDigitWeights = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    public CnpjValidator(string cnpj)
    {
      Cnpj = cnpj;
    }

    public bool IsValid()
    {
      int firstValidationDigit = GetFirstValidationDigit();
      int secondValidationDigit = GetSecondValidationDigit();
      return IsFirstValidationDigitEqualToSecondToLastOne(firstValidationDigit)
             && IsSecondValidationDigitEqualToLastOne(secondValidationDigit);
    }

    private bool IsFirstValidationDigitEqualToSecondToLastOne(int firstValidationDigit)
    {
      return (int)char.GetNumericValue(s: Cnpj, index: Cnpj.Length - 2) == firstValidationDigit;
    }

    private bool IsSecondValidationDigitEqualToLastOne(int secondValidationDigit)
    {
      return (int)char.GetNumericValue(s: Cnpj, index: Cnpj.Length - 1) == secondValidationDigit;

    }

    private int GetFirstValidationDigit()
    {
      return GetValidationDigit(weightsToMultiply: firstValidationDigitWeights);
    }

    private int GetSecondValidationDigit()
    {
      return GetValidationDigit(weightsToMultiply: secondValidationDigitWeights);
    }

    private int GetValidationDigit(int[] weightsToMultiply)
    {
      int digitsWeightSummation = 0;
      var digitWeightMutiplied = weightsToMultiply
                                .Select((number, index) =>
                                         number * (int)char.GetNumericValue(s: Cnpj, index: index));

      digitsWeightSummation = digitWeightMutiplied.Aggregate((int cumulator, int nextNumber) => cumulator += nextNumber);
      int operationRest = digitsWeightSummation % 11;
      if (operationRest < 2)
        return 0;
      return 11 - operationRest;
    }
  }
}
