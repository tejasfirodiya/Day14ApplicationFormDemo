using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Day14ApplicationFormDemo.ArctechInfo;
using Day14ApplicationFormDemo.ArctechInfo.Controls;

namespace Day14ApplicationFormDemo.WaiTech
{
    internal class RegistrationForm : Window
    {

        private const string Heading = "FirstName,LastName,Age,Male,Female,City,State,Country,University,Workplace\n";
        private const string FilePath = @"C:\test\RegistrationFormData.csv";

        private readonly Label _labelFirstName, _labelLastName, _labelAge, _labelGender, _labelCity, _labelState, _labelCountry, _labelUniversity, _labelWorkplace;
        private readonly TextBox _textBoxFirstName, _textBoxLastName, _textBoxAge, _textBoxMale, _textBoxFemale, _textBoxCity, _textBoxState, _textBoxCountry, _textBoxUniversity, _textBoxWorkplace;
        private readonly Button _buttonSave, _buttonCancel, _buttonMale, _buttonFemale;

        private readonly Label _labelStatus;

        public RegistrationForm(string title, int left, int top) :
            base(title, left, top, 100, 20)
        {
            _labelFirstName = new Label("First Name:", 2, 2);
            _textBoxFirstName = new TextBox(15, 2, 25);

            _labelLastName = new Label("Last Name:", 45, 2);
            _textBoxLastName = new TextBox(58, 2, 25);

            _labelAge = new Label("Age:", 2, 4);
            _textBoxAge = new TextBox(15, 4, 10);

            _labelGender = new Label("Gender:", 45, 4);

            _buttonMale = new Button("Male", 58, 4);
            _textBoxMale = new TextBox(65, 10, 6);
            _buttonMale.OnClicked += ButtonMaleOnOnClicked;

            _buttonFemale = new Button("Female", 68, 4);
            _textBoxFemale = new TextBox(75, 10, 6);
            _buttonFemale.OnClicked += ButtonFemaleOnOnClicked;

            _labelCity = new Label("City:", 2, 6);
            _textBoxCity = new TextBox(15, 6, 25);

            _labelState = new Label("State:", 45, 6);
            _textBoxState = new TextBox(58, 6, 25);

            _labelCountry = new Label("Country:", 2, 8);
            _textBoxCountry = new TextBox(15, 8, 25);

            _labelUniversity = new Label("University:", 45, 8);
            _textBoxUniversity = new TextBox(58, 8, 25);

            _labelWorkplace = new Label("Workplace:", 2, 10);
            _textBoxWorkplace = new TextBox(15, 10, 25);

            _buttonSave = new Button("Save Resume", 75, 16);
            _buttonSave.OnClicked += ButtonSaveOnOnClicked;

            _buttonCancel = new Button("Cancel", 89, 16);
            _buttonCancel.OnClicked += ButtonCancelOnOnClicked;

            _labelStatus = new Label("Registration Form Initialized. Please enter your Details.", 1, 18, 98);
            _labelStatus.SetColor(ConsoleColor.Black, ConsoleColor.Yellow);

            InitializeControl();
        }

        private void InitializeControl()     // ya madhe aapn sgle controls add krtoy 
        {
            AddControl(_labelFirstName);
            AddControl(_textBoxFirstName);

            AddControl(_labelLastName);
            AddControl(_textBoxLastName);

            AddControl(_labelAge);
            AddControl(_textBoxAge);

            AddControl(_labelGender);
            AddControl(_buttonMale);
            AddControl(_buttonFemale);

            AddControl(_labelCity);
            AddControl(_textBoxCity);

            AddControl(_labelState);
            AddControl(_textBoxState);

            AddControl(_labelCountry);
            AddControl(_textBoxCountry);

            AddControl(_labelUniversity);
            AddControl(_textBoxUniversity);

            AddControl(_labelWorkplace);
            AddControl(_textBoxWorkplace);

            AddControl(_buttonSave);
            AddControl(_buttonCancel);

            AddControl(_labelStatus);
        }

        private void ButtonFemaleOnOnClicked(object? sender, EventArgs e)
        {
            _textBoxFemale.Text = "Female";
            _textBoxMale.Text = "";
        }

        private void ButtonMaleOnOnClicked(object? sender, EventArgs e)
        {
            _textBoxMale.Text = "Male";
            _textBoxFemale.Text = "";
        }

        private void ButtonCancelOnOnClicked(object? sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSaveOnOnClicked(object? sender, EventArgs e)
        {
            var data = $"{_textBoxFirstName.Text},{_textBoxLastName.Text},{_textBoxAge.Text}," +
                $"{_textBoxMale.Text},{_textBoxFemale.Text},{_textBoxCity.Text},{_textBoxState.Text},{_textBoxCountry.Text}," +
                $"{_textBoxUniversity.Text},{_textBoxWorkplace.Text}\n";

            if (!File.Exists(FilePath))                      
                File.WriteAllText(FilePath, Heading);

            try
            {
                File.AppendAllText(FilePath, data);
                _labelStatus.Text = $"File successfully saved at {FilePath}";
            }
            catch (Exception exception)
            {
                _labelStatus.Text = $"Error Saving File. {exception.Message}";
            }

            _labelStatus.Show();
        }   //closing of ButtonSaveOnOnClicked
    }
}