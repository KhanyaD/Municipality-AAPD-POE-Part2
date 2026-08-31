# Municipal Services South Africa Application

## AAPD7112/w – Programming 3B
### Part 1: Municipal Services Application

**Student:** Kukhanya Dlanjwa  
**Student Number:** ST10364883

---

## 1. Project Overview

The Municipal Services South Africa Application is a Windows Forms
desktop application developed in C#.

The application is designed to provide South African citizens with a
simple interface for interacting with municipal services.

Part 1 of the application focuses on allowing citizens to report
municipal service-delivery issues.

The main menu contains the following options:

- Report Issues
- Local Events and Announcements
- Service Request Status

For Part 1, the Report Issues functionality is implemented.
The Local Events and Announcements and Service Request Status
features are reserved for later development.

---

## 2. Technologies Used

The application was developed using:

- C#
- Windows Forms (WinForms)
- Microsoft Visual Studio
- .NET
- Object-Oriented Programming principles
- Generic List data structure

---

## 3. Application Features

### Main Menu

When the application starts, the user is presented with the
Municipal Services South Africa main menu.

The main menu provides access to the Report Issues feature and
displays the current date.

### Report Municipal Issue

The Report Issues feature allows a citizen to provide:

- Location of the municipal issue
- Issue category
- Description of the issue
- Optional supporting image or document

Available issue categories include:

- Roads and Potholes
- Water and Sanitation
- Electricity
- Waste Management
- Street Lights
- Other

---

## 4. File Attachments

Users can attach supporting evidence to a municipal report.

The application uses an OpenFileDialog to allow the user to select
files from their computer.

Supported files include:

- JPG
- JPEG
- PNG
- PDF
- DOC
- DOCX

The selected filename is displayed on the Report Municipal Issue form.

---

## 5. User Engagement Strategy

The application implements Progress-Based Feedback and Positive
Reinforcement as its primary user engagement strategy.

A progress bar provides visual feedback while the citizen completes
the report.

Progress increases as the user:

1. Enters a location
2. Selects an issue category
3. Provides a description
4. Attaches supporting evidence

Each completed section contributes 25% toward the progress indicator.

The application also displays encouraging messages such as:

- "Great start! Keep going."
- "You are halfway there!"
- "Almost finished!"
- "Ready to submit your report!"

This provides immediate feedback and encourages users to complete
the reporting process.

---

## 6. Data Structure

Submitted municipal reports are represented by the ReportedIssue
class.

Each reported issue contains:

- Location
- Category
- Description
- Attachment path
- Date reported
- Reference number

Submitted reports are stored in:

List<ReportedIssue>

The IssueRepository class provides access to the collection of
reported municipal issues while the application is running.

---

## 7. Reference Numbers

When a municipal issue is successfully submitted, the application
generates a reference number.

Example:

MUN-20260817135018

The reference number is displayed to the citizen as part of the
successful submission confirmation.

---

## 8. Validation

Before a report can be submitted, the application validates the
required information.

The following fields are required:

- Location
- Category
- Description

If required information is missing, the application displays a
warning message and asks the user to complete the relevant field.

The supporting attachment is optional.

---

## 9. How to Compile the Application

1. Open the MunicipalServicesApp solution in Microsoft Visual Studio.
2. Allow Visual Studio to load the project completely.
3. Select **Build** from the Visual Studio menu.
4. Select **Build Solution**.

Alternatively, press:

Ctrl + Shift + B

5. Confirm that Visual Studio reports that the build succeeded with
no compilation errors.

---

## 10. How to Run the Application

1. Open the project in Microsoft Visual Studio.
2. Build the solution.
3. Press **F5** or select the **Start** button.
4. The Municipal Services South Africa main menu will open.
5. Select **Report Issues** to open the Report Municipal Issue form.

---

## 11. How to Report a Municipal Issue

1. Launch the application.
2. Click **Report Issues**.
3. Enter the location of the municipal issue.
4. Select the appropriate issue category.
5. Enter a description of the issue.
6. Optionally click **Attach File** to attach supporting evidence.
7. Observe the progress indicator as the report is completed.
8. Click **Submit Report**.
9. The application validates the information.
10. A successful submission message and municipal reference number
    are displayed.
11. Click **OK** to complete the submission.

The form is then cleared and is ready for another municipal report.

---

## 12. Navigation

The **Back** button on the Report Municipal Issue form returns the
user to the main menu.

The application uses separate Windows Forms for the main menu and
municipal issue reporting interface.

---

## 13. Project Structure

Important project files include:

- MainMenuForm.cs
  Handles the application's main menu and navigation.

- ReportIssueForm.cs
  Handles municipal issue reporting, validation, attachments,
  progress feedback and report submission.

- ReportedIssue.cs
  Defines the structure of a municipal issue.

- IssueRepository.cs
  Stores submitted issues using a List<ReportedIssue> collection.

- Program.cs
  Contains the application startup configuration.

---

## 14. Current Scope

This version represents Part 1 of the Municipal Services Application.

The following feature is currently implemented:

- Report Issues

The following main-menu features are reserved for subsequent parts
of the project:

- Local Events and Announcements
- Service Request Status

---

## 15. Conclusion

The Municipal Services South Africa Application provides citizens
with a straightforward way to report municipal service-delivery
problems.

The application combines input validation, file attachments,
appropriate data structures, confirmation messages, reference
numbers and progress-based user engagement to provide a clear and
user-friendly reporting experience.