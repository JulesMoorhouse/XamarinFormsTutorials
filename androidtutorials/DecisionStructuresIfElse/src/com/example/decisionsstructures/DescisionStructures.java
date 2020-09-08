package com.example.decisionsstructures;

import javax.swing.*;

public class DescisionStructures
{
    public static void main(String[] args)
    {
        int number;

        String input;

        input = JOptionPane.showInputDialog("Please enter a number: ");
        number = Integer.parseInt(input);

        if (number == 5)
        {
            JOptionPane.showMessageDialog(null, "The number is exactly 5!");
        }
        else if (number > 10)
        {
            JOptionPane.showMessageDialog(null, "The number is greater than 10!");
        }
        else if (number > 5)
        {
            JOptionPane.showMessageDialog(null, "The number is greater than 5!");
        }
        else
        {
            JOptionPane.showMessageDialog(null, "The number is less than 5!");
        }

        System.exit(0); // Better to use exit when using JOptionPane as it's faster
    }
}
