#!/bin/bash

# Script to create a Git repository, create a .gitignore file using dotnet-gitignore,
# add all files, and create an initial commit.

echo "Starting Git repository initialization..."

# --- Check and install dotnet-gitignore tool ---
echo "Checking if dotnet-gitignore tool is installed..."
if ! command -v dotnet-gitignore &> /dev/null
then
    echo "dotnet-gitignore tool not found. Attempting to install it globally..."
    dotnet tool install --global dotnet-gitignore
    if [ $? -ne 0 ]; then
        echo "Error: Failed to install dotnet-gitignore. Please ensure you have .NET SDK installed and try installing it manually using 'dotnet tool install --global dotnet-gitignore'."
        exit 1
    fi
    echo "dotnet-gitignore tool installed successfully. You might need to open a new terminal session for it to be available in your PATH."
else
    echo "dotnet-gitignore tool is already installed."
fi

# --- Create .gitignore file ---
echo "Creating .gitignore file for the solution..."
dotnet gitignore add visualstudio
if [ $? -eq 0 ]; then
    echo ".gitignore file created successfully."
else
    echo "Warning: Failed to create .gitignore file using dotnet-gitignore. You might need to create it manually."
fi

# --- Initialize Git repository ---
echo "Initializing Git repository..."
git init
if [ $? -eq 0 ]; then
    echo "Git repository initialized successfully."
else
    echo "Error: Failed to initialize Git repository."
    exit 1
fi

# --- Add all files to the staging area ---
echo "Adding all files to the staging area..."
git add .
if [ $? -eq 0 ]; then
    echo "All files added to the staging area."
else
    echo "Error: Failed to add files to the staging area."
    exit 1
fi

# --- Create the initial commit ---
echo "Creating the initial commit..."
git commit -m "Initial commit"
if [ $? -eq 0 ]; then
    echo "Initial commit created successfully."
else
    echo "Error: Failed to create the initial commit."
    exit 1
fi

echo "Git repository setup complete."