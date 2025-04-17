#!/bin/bash

# This script will add all changes (modified and untracked) and commit them
# with the message "Add dummy data to the database".

# Navigate three directories up to the root of the repository

# Add all changes to the staging area
git add .

# Commit the changes with the message
git commit -m "Add dummy data to the database"

echo "Successfully added and committed changes with the message: 'Add dummy data to the database'"