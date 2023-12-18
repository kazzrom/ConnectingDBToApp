using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.Messages;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Views.Pages;


namespace ConnectingDBToApp.ViewModels
{
    public partial class QuestionViewModel : ObservableObject, IRecipient<GetUsernameMessage>
    {
        public QuestionViewModel()
        {
            // Регистрация класса как получателя сообщений
            WeakReferenceMessenger.Default.Register(this);

            // Инициализация всех полей и свойств
            _countRightAnswers = 0;
            _username = string.Empty;
            TestQuestions = new Queue<TestQuestion>(DbContext.Tables.TestQuestions);
            _countQuestions = TestQuestions.Count;

            // Свойство с текущим вопросом на странице
            CurrentQuestion = TestQuestions.Dequeue();
        }

        // Поле с количеством вопросов
        private int _countQuestions;

        // Поле с количеством правильных ответов
        private int _countRightAnswers;

        // Поле с именем пользователя
        private string _username;

        // Очередь вопросов теста
        public Queue<TestQuestion> TestQuestions { get; set; }


        // Метод для получения сообщения о имени пользователя
        public void Receive(GetUsernameMessage message)
        {
            _username = message.Value;
            WeakReferenceMessenger.Default.UnregisterAll(this);
        }

        // Поле с объектом текущего вопроса
        [ObservableProperty]
        private TestQuestion _currentQuestion;

        // Поле с объектом выбранного варианта ответа
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextQuestionCommand))]
        private RadioButton _selectedRadioButton = null!;

        // Поле с текстом кнопки, переключающую вопросы
        [ObservableProperty]
        private string _buttonContent = "Далее";

        // Метод, выполняющийся при событии выбора варианта ответа
        [RelayCommand]
        private void CheckedRadioButton(RadioButton radioButton)
        {
            SelectedRadioButton = radioButton;
        }

        // Команда для показа следующего вопроса
        [RelayCommand(CanExecute = nameof(CanNextQuestion))]
        private void NextQuestion()
        {
            string selectedAnswer = SelectedRadioButton.Content.ToString()!;

            // Проверка, правильный ли выбранный ответ или нет
            if (selectedAnswer == CurrentQuestion.RightAnswer)
            {
                _countRightAnswers++;
            }

            // Проверка количества оставшихся вопросов и показ следующего вопроса
            if (TestQuestions.Count >= 1)
            {
                if (TestQuestions.Count == 1)
                    ButtonContent = "Завершить";

                CurrentQuestion = TestQuestions.Dequeue();
                SelectedRadioButton.IsChecked = false;
                SelectedRadioButton = null!;
            }
            else
            {
                // Вычисление результата и его добавление в БД
                var result = new TestResult()
                {
                    Username = _username,
                    CountRightAnswer = _countRightAnswers,
                    CountQuestions = _countQuestions,
                    Percentages = _countRightAnswers * 1.0 / _countQuestions
                };

                DbContext.Tables.Add(result);
                DbContext.Tables.SaveChanges();

                // Переход на страницу результата теста
                GlobalObjs.MainFrame.Navigate(new ResultPage());

                // Отправка результата на страницу теста
                WeakReferenceMessenger.Default.Send(new GetTestResultMessage(result));

                // Возвращение главного окна в изначальное состояние
                DoubleAnimation animation = new DoubleAnimation()
                {
                    To = 250,
                    Duration = TimeSpan.FromMilliseconds(200)
                };
                animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };
                GlobalObjs.SideBar.BeginAnimation(FrameworkElement.WidthProperty, animation);
                GlobalObjs.MenuButton.IsEnabled = true;
            }
        }

        // Проверка, выбран ли какой-то вариант ответа
        private bool CanNextQuestion()
        {
            return SelectedRadioButton != null;
        }
    }
}
