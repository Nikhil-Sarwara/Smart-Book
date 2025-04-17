#!/bin/bash

# Navigate to the root of your Smart Book project repository
cd "$(dirname "$0")"

# Function to add and commit files
commit_files() {
  local commit_message="$1"
  shift
  local files=("$@")

  if [ "${#files[@]}" -gt 0 ]; then
    echo "Adding files: ${files[@]}"
    git add "${files[@]}"
    if [ $? -eq 0 ]; then
      echo "Committing with message: \"$commit_message\""
      git commit -m "$commit_message"
      if [ $? -eq 0 ]; then
        echo "Commit successful."
      else
        echo "Error during commit."
      fi
    else
      echo "Error adding files."
    fi
  else
    echo "No files provided for commit: \"$commit_message\""
  fi
}

# Commit 1: Add Database Model Files
commit_files "Add Database Model Files" "SmartBook.Database/Models/"

# Commit 2: Update ApplicationDbContext with DbSet and configurations
commit_files "Update ApplicationDbContext with DbSet and configurations" "SmartBook.Database/Data/ApplicationDbContext.cs"

# Commit 3: Update ApplicationUser model
commit_files "Update ApplicationUser model" "SmartBook.Domain/Models/ApplicationUser.cs"

# Commit 4: Add bash scripts for model creation (assuming script.sh is one of them)
commit_files "Add bash scripts for model creation" "script.sh"

echo "Finished committing files. You might want to review the commits using 'git log'."
echo "Note: The files in the 'SmartBook.Database/obj' directory are build artifacts and are generally not committed to Git. Consider adding a '.gitignore' file to exclude them."