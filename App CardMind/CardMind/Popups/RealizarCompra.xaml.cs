using CardMind.Services.LocalServices;
using CommunityToolkit.Maui.Views;
using System.Runtime.CompilerServices;

namespace CardMind.Popups;

public partial class RealizarCompra : Popup
{
	private int valorEstilo;
	private string nomeEstilo = "";

	SistemaRecompensa sistemaRecompensa = new SistemaRecompensa();
	public RealizarCompra(SistemaRecompensa sistemaRecompensa)
	{
		this.sistemaRecompensa = sistemaRecompensa;
		InitializeComponent();
	}
	public RealizarCompra(int valor, string nomeEstilo)
	{
		InitializeComponent();
		lbPergunta.Text = "Comprar o estilo " + nomeEstilo + " por ";
		lbValor.Text = valor.ToString() + "?";

		valorEstilo = valor;
		this.nomeEstilo = nomeEstilo;

		btnSim.Clicked += Comprar;
		btnNao.Clicked += Recusar;
	}

	private void Comprar(object sender, EventArgs e)
	{
		bool comprado = sistemaRecompensa.ComprarEstilo(valorEstilo);
		Close(comprado);
	}
	private void Recusar(object sender, EventArgs e)
	{
		Close();
	}
}