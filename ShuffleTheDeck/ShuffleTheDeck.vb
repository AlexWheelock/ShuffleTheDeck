Option Explicit On
Option Strict On
Option Compare Text
'Alex Wheelock
'RCET 0265
'Spring 2024
'Shuffle The Deck
'https://github.com/AlexWheelock/ShuffleTheDeck.git

Imports System.Runtime.Remoting.Messaging



'TODO:
'[ ] Start New Game
'[ ] Draw a card
'[ ] Track which cards have been drawn
'[ ] Display which cards have been drawn
Module ShuffleTheDeck

    Sub Main()
        Dim userInput As String
        Dim tracker(13, 4) As Boolean

        Console.WriteLine("Welcome to Draw A Card!")
        Console.WriteLine()

        'Do
        Display(tracker)
        PickACard(tracker)

        'Loop Until userInput = "q"

        Console.WriteLine()
        Console.WriteLine("Thanks for playing!" & vbNewLine _
                          & "Have a great day!")

        Console.Read()
    End Sub

    Sub StartAGame(ByRef tracker(,) As Boolean)
        ReDim tracker(13, 4)
    End Sub

    Sub PickACard(ByRef tracker(,) As Boolean)
        Dim currentSuit As Integer
        Dim currentValue As Integer

        Do
            currentSuit = RandomNumberTo(4)
            currentValue = RandomNumberTo(13)
        Loop While tracker(currentValue, currentsuit)


    End Sub

    Function RandomNumberTo(max As Integer) As Integer
        Dim randomNumber As Integer

        Randomize()
        randomNumber = CInt(Math.Floor(Rnd() * (max + 2)))

        Return randomNumber
    End Function

    Sub Display(tracker(,) As Boolean)

        Dim temp(13, 4) As Boolean

        temp = tracker

        Dim suits() = {"S", "C", "H", "D"}
        Console.Clear()

        For Each letter In suits
            Console.Write(letter.PadLeft(2).PadRight(4))
        Next
        Console.WriteLine()


        For row = 0 To 13
            For column = 0 To 4
                If temp(row, column) Then
                    Console.WriteLine($" {(column * 13) + (row + 1)} |")
                Else console.Write("  |")
                End If
            Next
            Console.WriteLine()
        Next
    End Sub



End Module
