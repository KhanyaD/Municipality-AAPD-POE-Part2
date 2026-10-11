# Ubuntu Municipality  AAPD Part 2
Student: Kukhanya Dlanjwa | ST10364883

## Open, compile and run
1. Extract this ZIP into a normal folder on your Windows PC. Do not run from inside the ZIP.
2. In Visual Studio 2022, install the .NET desktop development workload and the .NET Framework 4.8 targeting/developer pack.
3. Open UbuntuMunicipality/MunicipalServicesApp.sln.
4. Select Debug and Any CPU. Right-click MunicipalServicesApp and choose Set as Startup Project.
5. Choose Build > Rebuild Solution (Ctrl+Shift+B). Resolve any errors before submission.
6. Press F5 to run. No database, internet connection or NuGet dependencies are needed.

## Using the application
Report Issues retains the Part 1 location, category, description, optional attachment, emergency flag and progress feedback. My Reports displays submitted issues during the current application session.

Click Local Events and Announcements on the main menu. Upcoming sample events and announcements display in chronological order. Select an item to read its location and description. Search a keyword (title, description, category or location), choose a category, and optionally tick Filter dates and select a start and end date. Dates are inclusive. Click Search or press Enter in the keyword box. Invalid date ranges show a warning; no matches show a clear message. Reset filters restores all upcoming items without clearing preferences.

Recommended for you updates after each meaningful search. Select a recommendation to read its details. Recent searches display newest first. Select a search and click Apply selected (or double-click it) to restore its filters. Clear history removes search preferences and recommendations. Back to Main Menu returns to the dashboard. Service Request Status remains a Part 3 placeholder.

The events are fictional demonstration records, not verified municipality announcements. Their dates are generated relative to the day the service first loads. Reports, event data and search history are in memory and reset when the application exits. No attachments are uploaded.

## Data structures and recommendation algorithm
- SortedDictionary<DateTime, List<MunicipalEvent>>: chronological event buckets. A list per date retains multiple items on the same day.
- Dictionary<int, MunicipalEvent>: direct ID lookup for event and recommendation details.
- HashSet<string>: unique categories for the category dropdown; unique explanation phrases in recommendations.
- Stack<EventSearch>: most recent search first, retaining the latest 20 meaningful searches. Reopening the events form keeps history for the application session.
- Recommendations scan the retained searches. Each matching category adds 5 points, matching keyword adds 3, and matching inclusive date range adds 2. Repeated searches increase the weight of recurring preferences. Positive scores are ranked descending, then by soonest date and ID; up to five suggestions display. The initial screen invites a search rather than claiming personalised suggestions without any history.

Stacks, dictionary structures and sets are actively used, as required by the brief's alternatives. This .NET Framework 4.8 project does not depend on the newer built-in PriorityQueue type.

## Source guide
- MainMenuForm.cs: navigation and today's date.
- LocalEventsForm.cs: events interface, filters, details, history and recommendation display; built in code rather than a Designer file.
- Events/MunicipalEvent.cs: event, search and recommendation models.
- Events/EventService.cs: demonstration data, indexes, search history and scoring algorithm.
- Existing ReportIssueForm, MyReportsForm and issue model/repository: Part 1 functionality.
- Evidence/MainMenu.png: main-menu screenshot supplied by the student.

## Verification status and checks
Verification completed on 8 October 2026:
- The .NET Framework 4.8 solution built successfully with 0 warnings and 0 errors.
- All 16 automated event-service checks passed.
- Windows Forms smoke tests successfully constructed MainMenuForm, ReportIssueForm, MyReportsForm and LocalEventsForm.
- Tests through the Local Events form passed: Sport category search returned two items; an inclusive single-date search retained both same-day items; Reset filters restored all 12 sample items.
- The student confirmed completion of visual checks and supplied the main-menu screenshot in Evidence/MainMenu.png. That screenshot documents the main menu; it does not independently establish the appearance of every other screen.

The tests above validate compilation, service logic and selected form behaviour. The manual checklist below is retained for repeat testing and is not a record of individually observed passes.

For optional automated event-service checks, open Command Prompt in this extracted folder and run Validation\RunChecks.cmd. It compiles and runs checks for chronological sorting, duplicate-date records, inclusive date bounds, combined filters, no results, category/keyword/date recommendations, repeated-search ranking, history limits, invalid ranges and clearing history. It exits with a nonzero code if compilation or a check fails. These checks do not replace the Visual Studio application build or UI checks.

Optional repeat checks on Windows:
1. Rebuild successfully and launch the app. Confirm today's date and working Report Issues navigation.
2. Open events; verify upcoming events and announcements, chronological dates and selected-item details.
3. Search Sport: only Sport items should appear; recommendations should show Sport matches.
4. Search Education twice: Education items should rank above the earlier Sport preferences.
5. Reset filters: all upcoming items return, with recommendations retained.
6. Filter the single date seven days from today: both the arts market and recycling notice should appear (when tested on the initial load day).
7. Search a nonexistent keyword: a no-matches message should appear.
8. Set From after To: a warning should appear without changing results/history.
9. Apply a recent search: filters/results restore without duplicating history.
10. Clear history: history empties and recommendations invite a new search.
11. Close/reopen events: retained searches persist until the app exits. Restarting the app clears session data.
12. Resize the events window and check navigation, grids and filters remain usable.

## Submission contents
This Part 2 package contains the complete application source, solution/project files, this README, automated event-service checks and the supplied main-menu screenshot. Generated .vs, bin and obj folders are excluded. Open the solution and rebuild to generate the executable.

The required Part 2 deliverables are source code and a README explaining compilation, running and use. A new research report is not required for Part 2. Service Request Status is reserved for Part 3. Retain a copy of this source for the final POE.

## Known limitations
Reports and preferences persist only for the current session. Report reference numbers use a timestamp to the nearest second, so rapid submissions can share a reference. The Report Issues progress bar includes the optional attachment in its percentage, so the three mandatory fields alone show 75 percent. These existing behaviours were identified during review; this submission packaging does not change application code.
