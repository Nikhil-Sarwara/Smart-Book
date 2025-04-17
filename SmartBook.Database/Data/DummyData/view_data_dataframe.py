import pandas as pd
import pyodbc  # Or pymssql

# Replace with your actual connection details
server = 'localhost'
database = 'SmartBookDb'
username = 'sa'
password = 'Tymnec@123'

# Connection string (adjust driver as needed)
connection_string = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'

def view_all_data():
    try:
        cnxn = pyodbc.connect(connection_string)
        cursor = cnxn.cursor()

        print("\n--- Authors Data ---")
        df_authors = pd.read_sql_query("SELECT * FROM Authors", cnxn)
        print(df_authors)

        print("\n--- Publishers Data ---")
        df_publishers = pd.read_sql_query("SELECT * FROM Publishers", cnxn)
        print(df_publishers)

        print("\n--- Genres Data ---")
        df_genres = pd.read_sql_query("SELECT * FROM Genres", cnxn)
        print(df_genres)

        print("\n--- Books Data ---")
        df_books = pd.read_sql_query("SELECT * FROM Books", cnxn)
        print(df_books)

        print("\n--- Users Data ---")
        df_users = pd.read_sql_query("SELECT * FROM Users", cnxn)
        print(df_users)

        cnxn.close()
    except pyodbc.Error as ex:
        sqlstate = ex.args[0]
        print(f"Error fetching data: {sqlstate}")
        print(ex)

if __name__ == "__main__":
    view_all_data()
