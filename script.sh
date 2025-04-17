#!/bin/bash

# Navigate to the root of the repository (if needed)
# cd ../../../

# Commit 1: Organize Repository files into Interfaces and Implementations folders
git add SmartBook.Api/Repositories/Interfaces
git add SmartBook.Api/Repositories/Implementations
git add SmartBook.Api/Repositories/*.cs # In case any files remained directly in the Repositories folder
git commit -m "Commit 1: Organize Repository files into Interfaces and Implementations folders"

# Commit 2: Update namespaces in Repository files (you'll need to do this manually in your IDE)
echo "Please update the namespaces in your repository files (e.g., IBookRepository.cs should be in SmartBook.Api.Repositories.Interfaces namespace)."
echo "After updating the namespaces, run the following command:"
echo "git add SmartBook.Api/Repositories/Interfaces/*.cs SmartBook.Api/Repositories/Implementations/*.cs"
echo "git commit -m \"Commit 2: Update namespaces in Repository files\""
echo ""
echo "Continuing with the next commit assuming you have updated the namespaces..."
echo ""
sleep 5 # Give some time for the user to read

# Commit 3: Organize DTO files into Requests and Responses folders
git add SmartBook.Api/Dtos/Requests
git add SmartBook.Api/Dtos/Responses
git add SmartBook.Api/Dtos/*.cs # In case any files remained directly in the Dtos folder
git commit -m "Commit 3: Organize DTO files into Requests and Responses folders"

# Commit 4: Update namespaces in DTO files (you'll need to do this manually in your IDE)
echo "Please update the namespaces in your DTO files (e.g., CreateBookDto.cs should be in SmartBook.Api.Dtos.Requests namespace)."
echo "After updating the namespaces, run the following command:"
echo "git add SmartBook.Api/Dtos/Requests/*.cs SmartBook.Api/Dtos/Responses/*.cs"
echo "git commit -m \"Commit 4: Update namespaces in DTO files\""
echo ""
echo "Continuing with the next commit assuming you have updated the namespaces..."
echo ""
sleep 5 # Give some time for the user to read

# Commit 5: Update using directives in Controllers (you'll need to do this manually in your IDE)
echo "Please update the using directives in your Controller files to reflect the new namespaces for your Repositories (e.g., using SmartBook.Api.Repositories.Interfaces;)."
echo "After updating the using directives, run the following command:"
echo "git add SmartBook.Api/Controllers/*.cs"
echo "git commit -m \"Commit 5: Update using directives in Controllers for Repositories\""

echo "All commit steps outlined. Please follow the instructions in the output."