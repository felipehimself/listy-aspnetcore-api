# List Recommendations API

Welcome to the List Recommendations API! <br><br>
This API provides a platform for users to create, share, and discover lists of recommendations for various categories such as movies, series, places, restaurants, and more. Users can create an account, log in securely via JWT token, create lists, comment on lists, and interact with other users' recommendations.

## Features

- **User Authentication**: Secure login system based on JWT token authentication.
- **List Creation**: Users can create lists for different categories, each containing up to 5 items.
- **List Management**: Ability to create, edit, and delete lists.
- **Commenting**: Users can comment on lists to share their thoughts and opinions.
- **Admin Privileges**: Super admins have access to additional functionalities such as user role management.

## Technical Details

- **Framework**: ASP.NET Core Web API
- **Controllers**:
  - **Admin**: Allows super admins to manage user roles.
  - **Categories**: Manages categories for lists, including creation, deletion, and updating.
  - **Comments**: Handles comments on lists.
  - **Lists**: Provides CRUD operations for lists.
  - **Login**: Handles user authentication and JWT token generation.
  - **Users**: Manages user accounts and profiles.

## Endpoints

- **Admin**
  - `PATCH /api/admin`: Change user role from 'user' to 'admin' (Super admin only).
- **Categories**
  - `GET /api/categories`: Get all categories.
  - `POST /api/categories`: Create a category (Admin only).
  - `PUT /api/categories`: Update a category (Admin only).
  - `DELETE /api/categories`: Delete a category (Admin only).
- **Comments**
  - `POST /api/comments`: Create a comment.
  - `PUT /api/comments`: Update a comment.
  - `DELETE /api/comments`: Delete a comment.
- **Lists**
  - `GET /api/lists`: Get all lists.
  - `POST /api/lists`: Create a list.
  - `PUT /api/lists`: Update a list.
  - `GET /api/lists/{id}`: Get a single list.
  - `DELETE /api/lists/{id}`: Delete a list.
- **Login**
  - `POST /api/login`: User login and JWT token generation.
- **Users**
  - `GET /api/users`: Get all users (Admin only).
  - `POST /api/users`: Create a user account.
  - `PUT /api/users`: Update user data.
  - `GET /api/users/{id}`: Get a single user.
  - `DELETE /api/users/{id}`: Delete user account.
  - `PATCH /api/users/update-password`: Update user password.

## Getting Started

1. Clone this repository.
2. Install dependencies.
3. Configure database connection.
4. Run the application.
5. Access the API endpoints using your preferred client.

## Contributing

Contributions are welcome! Feel free to open issues or pull requests for any enhancements or bug fixes.

## License

This project is licensed under the [MIT License](LICENSE).
