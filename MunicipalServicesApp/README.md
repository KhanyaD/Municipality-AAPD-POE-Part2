UBUNTU MUNICIPALITY
POE Part 2 README
Module: Application Development
Project: Ubuntu Municipality Municipal Services Application
Student Name: Kukhanya Dlanjwa
Student Number: ST10364883
Submission: POE Part 2
GitHub Repository
 Part 2 repository: https://github.com/KhanyaD/Municipality-AAPD-POE-Part2

The repository link for the revised Part 2 source must be confirmed before submission.
1 Project Overview
Ubuntu Municipality is a Windows Forms application developed in C# using Microsoft Visual Studio. The application is designed to provide residents with an accessible platform for interacting with municipal services.
POE Part 2 extends the application with Local Events and Announcements. Residents can browse upcoming items, search by keyword, category and date, and receive recommendations based on their search history. This README explains the features and supplied screenshot evidence. The revised selection fix still requires a Windows build and regression retest.
2 Purpose of the Application
The application provides a central interface for municipal service interactions. Part 2 adds access to local events and announcements while retaining Report Issues from Part 1. Service Request Status remains a placeholder for Part 3.

 3 Main menu and return navigation
After selecting Back to Main Menu, the dashboard is displayed. The menu contains Report Issues, Local Events and Announcements, and Service Request Status. Return navigation was observed successfully.
 
Source: user-supplied Windows application screenshot, 6 October 2026. Pre-fix version.

 4 Initial events and announcements view
The page opens with 12 upcoming items, today’s date, event and announcement types, and selected-item details. Recommendations initially invite the user to search.
 
Source: user-supplied Windows application screenshot, 6 October 2026. Pre-fix version.

 5 Sport category search and recommendations
Searching Sport returns Youth football day and Community fun run. Both are recommended with the reason Matches a searched category. The Sport search appears in recent history.
 

6 Inclusive single-day date search
From and To are both 13 October 2026. The upcoming list contains Local arts market and Recycling collection notice, confirming that both records on the same date are retained and both date boundaries are inclusive.
 
7 Keyword search
Searching football returns only Youth football day. The search is stored in history and the recommendation explanation includes a keyword match.
 

 8 No matching events
Searching zzzz leaves the upcoming results empty and displays a helpful No matches message. Historical recommendations remain available. The details panel still shows a recommendation; selection handling has since been revised and needs a retest.
 
9 Invalid date-range validation
From is 20 October 2026 and To is 13 October 2026. The app displays Invalid date range / Choose a valid start and end date. The preceding valid results remain visible and the invalid search is absent from history.
 

 10 Reset filters and clear history
All 12 upcoming items are restored, recent searches are empty and recommendations return to the search prompt. These functions passed. This image also exposed a separate selection/details mismatch; it is retained as honest evidence of the pre-fix state.
 
11 Apply an earlier search
After the guided Sport and Education searches and applying the earlier Sport search, the category and two Sport results are restored. History contains only the two existing entries without duplication. The history list’s highlight returns to Education after refreshing; the actual category and results show Sport.
 
 12 History retained after reopening
After returning to the menu and reopening events, Education and Sport searches and their recommendations remain. This demonstrates in-session retention, not persistence after exiting the application. The pre-fix automatic details mismatch is visible here.
 
13 Selected announcement details
Water maintenance notice is selected in the upcoming list. Its details match the title, 9 October 2026, Utilities announcement type and North End location.
 

 14 Selected recommendation details
Digital skills workshop is selected in the recommendation list. Details match 11 October 2026, Education and Community library. Both grids were selected in this pre-fix image; the updated code clears the other grid’s highlight.
 
15 Data Structures and Recommendation Algorithm
SortedDictionary<DateTime, List<MunicipalEvent>>: chronological event buckets. A list per date retains multiple items on the same day.
Dictionary<int, MunicipalEvent>: direct ID lookup for event and recommendation details.
HashSet<string>: unique categories for the category dropdown; unique explanation phrases in recommendations.
Stack<EventSearch>: most recent search first, retaining the latest 20 meaningful searches. Reopening the events form keeps history for the application session.
Recommendations scan the retained searches. Each matching category adds 5 points, matching keyword adds 3, and matching inclusive date range adds 2. Repeated searches increase the weight of recurring preferences. Positive scores are ranked descending, then by soonest date and ID; up to five suggestions display. The initial screen invites a search rather than claiming personalised suggestions without any history.
Stacks, dictionary structures and sets are actively used, as required by the brief's alternatives. This .NET Framework 4.8 project does not depend on the newer built-in PriorityQueue type.


16 Source Code Guide
MainMenuForm.cs navigation and today's date.
LocalEventsForm.cs events interface, filters, details, history and recommendation display; built in code rather than a Designer file.
Events/MunicipalEvent.cs  sevent, search and recommendation models.
Events/EventService.cs demonstration data, indexes, search history and scoring algorithm.
Existing ReportIssueForm, MyReportsForm and issue model/repository: Part 1 functionality.
Part1Reference/: original Part 1 research and screenshot README, retained as reference. Use this current README for Part 2.
Captioned source code images are included in the Part 2 source code evidence section at the end of this README.
17 Technologies Used
Microsoft Visual Studio 2022, C#, Windows Forms, .NET Framework 4.8, Git and GitHub.
18 Opening Building and Running the Project
1. Extract this ZIP into a normal folder on your Windows PC. Do not run from inside the ZIP.
2. In Visual Studio 2022, install the .NET desktop development workload and the .NET Framework 4.8 targeting/developer pack.
3. Open UbuntuMunicipality/MunicipalServicesApp.sln.
4. Select Debug and Any CPU. Right-click MunicipalServicesApp and choose Set as Startup Project.
5. Choose Build > Rebuild Solution (Ctrl+Shift+B). Resolve any errors before submission.
6. Press F5 to run. No database, internet connection or NuGet dependencies are needed.
19 Application Behaviour and Limitations
Report Issues retains the Part 1 location, category, description, optional attachment, emergency flag and progress feedback. My Reports displays submitted issues during the current application session.
Click Local Events and Announcements on the main menu. Upcoming sample events and announcements display in chronological order. Select an item to read its location and description. Search a keyword (title, description, category or location), choose a category, and optionally tick Filter dates and select a start and end date. Dates are inclusive. Click Search or press Enter in the keyword box. Invalid date ranges show a warning; no matches show a clear message. Reset filters restores all upcoming items without clearing preferences.
Recommended for you updates after each meaningful search. Select a recommendation to read its details. Recent searches display newest first. Select a search and click Apply selected (or double-click 

 20 Testing and Verification
The following outcomes were recorded from screenshots supplied on 6 October 2026. They demonstrate the earlier running application and do not establish that the revised selection fix has passed.
Test	Observed outcome	Status	Evidence
Open events	Page displays 12 upcoming sample records	Passed in supplied runtime screenshot	02
Category filter and recommendations	Sport returns and recommends its two records	Passed	03
Single-day filter	Both 13 October records displayed	Passed	04
Keyword search	football returns Youth football day	Passed	05
No results	zzzz shows an empty list and helpful message	Passed for result list/message	06
Invalid dates	End before start produces warning	Passed	07
Reset and clear history	12 items restored; history and recommendations empty	Passed for reset/history functions	08
Apply history	Earlier Sport search restored without duplicate entries	Expected final state observed after guided steps	09
Return navigation	Main menu displayed again	Passed after guided steps	01
Session history	Education and Sport retained on reopening	Passed after guided steps	10
Selected event details	Water notice details match selection	Passed	11
Selected recommendation details	Workshop details match recommendation	Passed	12
Details after automatic refresh	Mismatched event/details observed in earlier screens	Fix implemented; retest pending	08, 10
Revised source build and automated checks	Not yet run on Windows	Pending	Capture build/check output
21 GitHub Repository and Project Files

The Part 1 README identifies https://github.com/KhanyaD/Municipality-AAPD-POE-Part1. Confirm the link or branch containing the final Part 2 source and record it before submission. Do not assume that the Part 1 repository already contains the changes.
Package this README, all evidence images, the complete Visual Studio solution and project files, and the Validation folder if included in the final project. The previously supplied Part 2 ZIP is incomplete and must be recreated from the complete source folder. Extract the final ZIP to a new folder and verify that its solution opens and builds.
22 Conclusion
POE Part 2 introduces browsing, filtering and personalised recommendations for local events and announcements. The supplied screenshots demonstrate the principal search and history features. Final submission readiness depends on confirming the revised build, retesting selection handling, updating the evidence and repository link, and validating the complete submission ZIP.

 Part 2 source code evidence
The following images reproduce the project source code in a Visual Studio styled editor. They are recreated code images, not screenshots of a running Visual Studio session. Original filenames and source line numbers are retained. The existing application output evidence is preserved above.

 Source code 1
 
Code Figure 1. Events/EventService.cs, lines 1 to 30. Event storage, category management, filtering, search history and ranked recommendations.
Recreated from the submitted project source code.

 Source code 2
 
Code Figure 2. Events/EventService.cs, lines 31 to 60. Event storage, category management, filtering, search history and ranked recommendations.
Recreated from the submitted project source code.

 Source code 3
 
Code Figure 3. Events/EventService.cs, lines 61 to 90. Event storage, category management, filtering, search history and ranked recommendations.
Recreated from the submitted project source code.

 Source code 4
 
Code Figure 4. Events/EventService.cs, lines 91 to 120. Event storage, category management, filtering, search history and ranked recommendations.
Recreated from the submitted project source code.

 Source code 5
 
Code Figure 5. Events/EventService.cs, lines 121 to 138. Event storage, category management, filtering, search history and ranked recommendations.
Recreated from the submitted project source code.

 Source code 6
 
Code Figure 6. Events/MunicipalEvent.cs, lines 1 to 30. Data models for events, search criteria and recommendations.
Recreated from the submitted project source code.

 Source code 7
 
Code Figure 7. Events/MunicipalEvent.cs, lines 31 to 38. Data models for events, search criteria and recommendations.
Recreated from the submitted project source code.

 Source code 8
 
Code Figure 8. LocalEventsForm.cs, lines 1 to 30. Interface setup, controls, search execution, results, recommendations and validation.
Recreated from the submitted project source code.

 Source code 9
 
Code Figure 9. LocalEventsForm.cs, lines 31 to 60. Interface setup, controls, search execution, results, recommendations and validation.
Recreated from the submitted project source code.

 Source code 10
 
Code Figure 10. LocalEventsForm.cs, lines 61 to 90. Interface setup, controls, search execution, results, recommendations and validation.
Recreated from the submitted project source code.

 Source code 11
 
Code Figure 11. LocalEventsForm.cs, lines 91 to 120. Interface setup, controls, search execution, results, recommendations and validation.
Recreated from the submitted project source code.

 Source code 12
 
Code Figure 12. LocalEventsForm.cs, lines 121 to 150. Interface setup, controls, search execution, results, recommendations and validation.
Recreated from the submitted project source code.

 Source code 13
 
Code Figure 13. LocalEventsForm.cs, lines 151 to 180. Interface setup, controls, search execution, results, recommendations and validation.
Recreated from the submitted project source code.

 Source code 14
 
Code Figure 14. LocalEventsForm.cs, lines 181 to 212. Interface setup, controls, search execution, results, recommendations and validation.
Recreated from the submitted project source code.









22 GitHub Repository and Project Files
The Part 1 README identifies https://github.com/KhanyaD/Municipality-AAPD-POE-Part1. Confirm the link or branch containing the final Part 2 source and record it before submission. Not assuming that the Part 1 repository already contains the changes.
Package this README, all evidence images, the complete Visual Studio solution and project files, and the Validation folder if included in the final project. The previously supplied Part 2 ZIP is incomplete and must be recreated from the complete source folder. Extract the final ZIP to a new folder and verify that its solution opens and builds.



23 Conclusion
POE Part 2 introduces browsing, filtering and personalised recommendations for local events and announcements. The supplied screenshots demonstrate the principal search and history features. Final submission readiness depends on confirming the revised build, retesting selection handling, updating the evidence and repository link, and validating the complete submission ZIP.

