using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain.Validators.DocumentValidators
{
  //Regras de validação retirados do site Só matemática disponível em:
  //https://www.somatematica.com.br/faq/Cpf.php#:~:text=Regra%20Pr%C3%A1tica,ser%20todos%20iguais%20entre%20si.
  public class CpfValidator
  {
    private String Cpf;

    public CpfValidator(string cpf)
    {
      Cpf = cpf;
    }

    public bool IsValid()
    {
      return Regex.IsMatch(Cpf, @"^(\d{3}){2}\d{3}\d{2}$") && AreCpfDigitsValid();

    }

    private bool AreCpfDigitsValid()
    {
      return AreDigitsTheSame() && AreValidationDigitsCorrect();

    }

    private bool AreDigitsTheSame()
    {
      return Cpf.All(c => c == Cpf[0]);
    }

    private bool AreValidationDigitsCorrect()
    {
      if (IsFirstValidationNumberEqualToSecondToLast())
        return false;
      return IsSecondValidationNumberEqualToLast();
    }

    private int GetValidationDigit(bool getSecondDigit = true)
    {
      int blockSum = getSecondDigit ? GetBlockSumForFirstDigit() : GetBlockSumForSecondDigit();
      return GetValidationDigitFromBlockSum(blockSum);
    }
    private int GetValidationDigitFromBlockSum(int blockSum)
    {
      int numberToDivide = Cpf.Length;
      int divisionRest = blockSum % numberToDivide;
      if (divisionRest == 0 || divisionRest == 1)
        return 0;
      return numberToDivide - divisionRest;
    }

    private int GetBlockSumForFirstDigit()
    {
      return GetBlockSum(numberToGetMultiplier: 11, numberToRange: 10);
    }

    private int GetBlockSumForSecondDigit()
    {
      return GetBlockSum(numberToGetMultiplier: 11, numberToRange: 10);
    }

    private int GetBlockSum(int numberToGetMultiplier, int numberToRange)
    {
      int digitsSum = 0;
      for (int cpfDigitIndex = 0; cpfDigitIndex < numberToRange; cpfDigitIndex++)
      {
        int numberToMultiply = numberToGetMultiplier - cpfDigitIndex;
        digitsSum += (int)char.GetNumericValue(s: Cpf, index: cpfDigitIndex) * numberToMultiply;
      }
      return digitsSum;
    }

    private bool IsFirstValidationNumberEqualToSecondToLast()
    {
      int firstValidationDigit = GetValidationDigit();
      return firstValidationDigit != Cpf[Cpf.Length - 2];
    }

    private bool IsSecondValidationNumberEqualToLast()
    {
      int secondValidationDigit = GetValidationDigit(getSecondDigit: true);
      return secondValidationDigit != Cpf[Cpf.Length - 1];
    }
  }
}
