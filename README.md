# Photo Match

Photo Match is a desktop application developed in **Visual Basic .NET** for detecting and managing duplicate and visually similar images in local directories.

The application identifies both **exact duplicates** and **visually similar images**, groups related files, and allows the user to decide how to manage them in an intuitive way.

## Key Features

- Exact duplicate detection using **MD5 hash**
- Visual similarity detection using **SSIM**
- Automatic grouping of related images
- Drag & drop image support
- Manual file management (keep, move, delete)
- Operation logging via text files
- Native Windows desktop interface

## Technologies

- Visual Basic .NET
- Windows Forms
- MD5 hashing
- SSIM (Structural Similarity Index)

## Project Structure

The project is organized in a modular way, separating responsibilities such as:

- Image preprocessing and analysis  
- Image comparison and grouping  
- File system operations  
- Logging and notifications  

This design improves maintainability and makes future extensions easier.

## Authors

- **Miguel González Fernández**

## License

This project is licensed under the **MIT License**.