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
        Dim cardsDrawn As Integer = 0
        Dim message As String = ("Welcome to Draw A Card!" & vbNewLine _
                          & "Press " & Chr(34) & "D" & Chr(34) & " to draw a card, " & Chr(34) & "N" & Chr(34) & " to start a new game, or " & Chr(34) & "Q" & Chr(34) & " to quit.")


        StartAGame(tracker)

        Do
            Display(tracker)
            Console.WriteLine()
            Console.WriteLine(message)
            userInput = Console.ReadLine()
            If userInput = "q" Then
                Console.WriteLine()
                Console.WriteLine("Thanks for playing!" & vbNewLine _
                              & "Have a great day!")
                Console.Read()
                Exit Sub
            ElseIf userInput = "n" Then
                StartAGame(tracker)
                cardsDrawn = 0
            Else
                If cardsDrawn >= 52 Then
                    message = ("All cards have been drawn..." & vbNewLine _
                        & "Press " & Chr(34) & "N" & Chr(34) & " to start a new game, or " & Chr(34) & "Q" & Chr(34) & " to quit.")
                Else
                    PickACard(tracker)
                    cardsDrawn += 1
                    message = "Press " & Chr(34) & "D" & Chr(34) & " to draw a card, " & Chr(34) & "N" & Chr(34) & " to start a new game, or " & Chr(34) & "Q" & Chr(34) & " to quit."
                End If
            End If
        Loop Until userInput = "q"

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

        tracker(currentValue, currentSuit) = True

    End Sub

    Function RandomNumberTo(max As Integer) As Integer
        Dim randomNumber As Integer

        Randomize()
        randomNumber = CInt(Math.Floor(Rnd() * max))

        Return randomNumber
    End Function

    Sub Display(tracker(,) As Boolean)

        Dim temp(13, 4) As Boolean
        Dim card As String

        temp = tracker

        Dim suits() = {"S", "C", "H", "D"}
        Console.Clear()

        For Each letter In suits
            Console.Write(letter.PadLeft(2).PadRight(4))
        Next
        Console.WriteLine()

        For row = 0 To 12
            For column = 0 To 3
                If temp(row, column) Then
                    Select Case row
                        Case 0
                            card = "2"
                        Case 1
                            card = "3"
                        Case 2
                            card = "4"
                        Case 3
                            card = "5"
                        Case 4
                            card = "6"
                        Case 5
                            card = "7"
                        Case 6
                            card = "8"
                        Case 7
                            card = "9"
                        Case 8
                            card = "10"
                        Case 9
                            card = "J"
                        Case 10
                            card = "Q"
                        Case 11
                            card = "K"
                        Case 12
                            card = "A"
                    End Select
                    If card = "10" Then
                        Console.Write(($" {card}|").PadLeft(3).PadRight(4))
                    Else
                        Console.Write(($" {card} |").PadLeft(3).PadRight(4))
                    End If
                Else
                    Console.Write(("   |").PadLeft(3).PadRight(4))
                End If
            Next
            Console.WriteLine()
        Next
    End Sub



End Module
