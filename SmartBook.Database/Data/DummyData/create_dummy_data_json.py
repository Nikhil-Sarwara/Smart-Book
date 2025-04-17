import json
from faker import Faker
from datetime import datetime

fake = Faker()

def generate_dummy_authors(num_authors=5):
    authors = []
    for i in range(num_authors):
        author = {
            "AuthorId": i + 1,
            "Name": fake.name(),
            "Biography": fake.paragraph()
        }
        authors.append(author)
    return authors

def generate_dummy_publishers(num_publishers=3):
    publishers = []
    for i in range(num_publishers):
        publisher = {
            "PublisherId": i + 1,
            "Name": fake.company(),
            "Location": fake.city() + ", " + fake.country()
        }
        publishers.append(publisher)
    return publishers

def generate_dummy_genres(num_genres=5):
    genres = []
    for i in range(num_genres):
        genre = {
            "GenreId": i + 1,
            "Name": fake.word().capitalize(),
            "Description": fake.sentence()
        }
        genres.append(genre)
    return genres

def generate_dummy_books(num_books=10, authors=None, publishers=None, genres=None):
    books = []
    if authors is None:
        authors = generate_dummy_authors(3) # Generate some authors if not provided
    if publishers is None:
        publishers = generate_dummy_publishers(2) # Generate some publishers if not provided
    if genres is None:
        genres = generate_dummy_genres(4) # Generate some genres if not provided

    for i in range(num_books):
        book = {
            "BookId": i + 1,
            "Title": fake.sentence(nb_words=5).rstrip('.'),
            "ISBN": fake.isbn13(),
            "PublicationDate": fake.date_time_between(start_date='-10y', end_date='now').isoformat(),
            "PublisherId": fake.random_element(publishers)['PublisherId'] if publishers else None
        }
        books.append(book)
    return books

def generate_dummy_users(num_users=5):
    users = []
    for i in range(num_users):
        user = {
            "UserId": i + 1,
            "Username": fake.user_name(),
            "Email": fake.email(),
            "Password": "password123", # In a real app, hash this!
            "Name": fake.name(),
            "RegistrationDate": datetime.now().isoformat()
        }
        users.append(user)
    return users

if __name__ == "__main__":
    dummy_data = {
        "Authors": generate_dummy_authors(),
        "Publishers": generate_dummy_publishers(),
        "Genres": generate_dummy_genres(),
        "Books": generate_dummy_books(),
        "Users": generate_dummy_users()
        # Add more models as needed (BookAuthor, BookGenre, Loan, ReadingProgress, Review)
    }
    with open("dummy_data.json", "w") as f:
        json.dump(dummy_data, f, indent=4)
    print("Dummy data created in dummy_data.json")
