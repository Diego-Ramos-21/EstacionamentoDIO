using Estacionamento.APP;
using Estacionamento.Common.Models;

EstacionamentoModel obj = new EstacionamentoModel();
bool valid = true;
int optionUser = 0;
do
{
	try
	{
		Console.Clear();
		Interface.Start();
		Console.Write("Informe o preço padrão: ");
		obj.PriceDefault = decimal.Parse(Console.ReadLine() ?? "NaN");
		Console.Write("Informe o preço por hora: ");
		obj.PriceByHour = decimal.Parse(Console.ReadLine() ?? "NaN");
        valid = true;
    }
    catch (Exception e)
	{
		Interface.Error(e.Message);
		valid = false;
	}
} while (!valid);
do
{
	try
	{
		Console.Clear();
		Interface.Start();
		Interface.Menu();
        Console.Write("Selecione uma opção: ");
		optionUser = int.Parse(Console.ReadLine() ?? "NaN");
		switch (optionUser)
		{
			case 1:
				Console.Write("Informe a placa do veiculo: ");
				obj.Create(Console.ReadLine() ?? "NULL");
				break;
			case 2:
				List<string> cars = obj.GetCars();
                int index = 0;
				int spendTime = 0;
				Interface.ListItens(cars.ToArray());
				if (cars.Count == 0) 
				{
                    Interface.Continues();
                    break; 
				}
				Console.Write("Selecione o carro para ser removido: ");
				index = int.Parse(Console.ReadLine() ?? "NaN") - 1;
				if (index >= cars.Count) throw new ArgumentOutOfRangeException($"O valor {index + 1} não existe nas opções selecionadas.");
				Console.Write("Quanto tempo o veiculo ficou no estacionamento (Hora): ");
				spendTime = int.Parse(Console.ReadLine() ?? "NaN");
				string vehicle = obj.GetCarById(index);
                decimal price = obj.RemoveCar(index, spendTime);
				Interface.CloseCashier(price, vehicle);
				Interface.Continues();
                break;
			case 3:
                Interface.ListItens(obj.GetCars().ToArray());
				Interface.Continues();
                break;
			case 4:
				Interface.Stop();
				break;
			default:
				throw new Exception("Valor inserido não é reconhecido pelo menu.");
		}
	}
	catch (Exception e)
	{
		Interface.Error(e.Message);
	}
} while (optionUser != 4);