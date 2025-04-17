import json
import pyodbc  # Or pymssql

# Replace with your actual connection details
server = 'localhost'
database = 'SmartBookDb'
username = 'sa'
password = 'Tymnec@123'

# Connection string (adjust driver as needed)
connection_string = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'

def embed_data(json_file="dummy_data.json"):
    try:
        with open(json_file, 'r') as f:
            data = json.load(f)
            cnxn = pyodbc.connect(connection_string)
            cursor = cnxn.cursor()

            # Embed Authors
            authors = data.get("Authors")
            if authors:
                for author in authors:
                    cursor.execute("INSERT INTO Authors (AuthorId, Name, Biography) VALUES (?, ?, ?)",
                                   author['AuthorId'], author['Name'], author['Biography'])
                cnxn.commit()
                print("Authors data embedded.")

            # Embed Publishers
            publishers = data.get("Publishers")
            if publishers:
                for publisher in publishers:
                    cursor.execute("INSERT INTO Publishers (PublisherId, Name, Location) VALUES (?, ?, ?)",
                                   publisher['PublisherId'], publisher['Name'], publisher['Location'])
                cnxn.commit()
                print("Publishers data embedded.")

            # Embed Genres
            genres = data.get("Genres")
            if genres:
                for genre in genres:
                    cursor.execute("INSERT INTO Genres (GenreId, Name, Description) VALUES (?, ?, ?)",
                                   genre['GenreId'], genre['Name'], genre['Description'])
                cnxn.commit()
                print("Genres data embedded.")

            # Embed Books
            books = data.get("Books")
            if books:
                for book in books:
                    cursor.execute("INSERT INTO Books (BookId, Title, ISBN, PublicationDate, PublisherId) VALUES (?, ?, ?, ?, ?)",
                                   book['BookId'], book['Title'], book['ISBN'], book['PublicationDate'], book['PublisherId'])
                cnxn.commit()
                print("Books data embedded.")

            # Embed Users
            users = data.get("Users")
            if users:
                for user in users:
                    cursor.execute("INSERT INTO Users (UserId, Username, Email, Password, Name, RegistrationDate) VALUES (?, ?, ?, ?, ?, ?)",
                                   user['UserId'], user['Username'], user['Email'], user['Password'], user['Name'], user['RegistrationDate'])
                cnxn.commit()
                print("Users data embedded.")

            cnxn.close()
            print("Data embedding process completed.")

    except FileNotFoundError:
        print(f"Error: {json_file} not found.")
    except pyodbc.Error as ex:
        sqlstate = ex.args[0]
        print(f"Error embedding data: {sqlstate}")
        print(ex)

if __name__ == "__main__":
    embed_data()
