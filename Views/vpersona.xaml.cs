using ksalazarS5Online.Models;

namespace ksalazarS5Online.Views;

public partial class vpersona : ContentPage
{
	public vpersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		lblMensaje.Text = "";
		App.personaRepository.AddNewPerson(txtNombre.Text);

		lblMensaje.Text = App.personaRepository.mensaje;
    }

	private void btnListar_Clicked(object sender, EventArgs e) 
	{

		lblMensaje.Text = "";
		List<persona> person= App.personaRepository.GetAllPeople();
		listaPersonas.ItemsSource = person;
		lblMensaje.Text= App.personaRepository.mensaje;

	}



    //BOTON ELIMINAR

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
        try
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                lblMensaje.Text = "Debe ingresar un ID para eliminar.";
                return;
            }

            int id = int.Parse(txtId.Text);
            App.personaRepository.DeletePerson(id);
            lblMensaje.Text = App.personaRepository.mensaje;

            // Actualizar la lista
            listaPersonas.ItemsSource = App.personaRepository.GetAllPeople();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = "Error: " + ex.Message;
        }
    }
    //BOTON ACTUALIZAR
    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
        try
        {
            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                lblMensaje.Text = "Debe ingresar el ID y el nuevo nombre para actualizar.";
                return;
            }

            int id = int.Parse(txtId.Text);
            string nuevoNombre = txtNombre.Text;

            persona personaActualizada = new persona()
            {
                Id = id,
                Nombre = nuevoNombre
            };

            App.personaRepository.UpdatePerson(personaActualizada);
            lblMensaje.Text = App.personaRepository.mensaje;

            // Actualizar la lista
            listaPersonas.ItemsSource = App.personaRepository.GetAllPeople();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = "Error: " + ex.Message;
        }
    }


    
}