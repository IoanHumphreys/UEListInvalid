# UEListInvalid

## Description
UEListInvalid is a utility designed to streamline the process of identifying and logging invalidated actors within Unreal Engine Fortnite projects. By parsing through the project's log files, UEListInvalid extracts and compiles a list of validation errors related to actors, providing a clear overview in a separate log file.

## Setup

1. **Open Unreal Engine:**
   - Launch Unreal Engine (UEFN) and load your project.
   
2. **Generate Validation Errors:**
   - Use the [JMAP tool](https://discord.gg/xMk2NargfJ) to import Points of Interest (POIs) or employ a tool like Blenderumap to ensure the session triggers validation errors in the output log.

3. **Locate Log Files:**
   - Navigate to the AppData directory:
     - **Windows:** Go to `C:\Users\YourUsername\AppData\Local`.
   - Find the `UnrealEditorFortnite\Saved\Logs` directory within AppData.

4. **Copy Log Directory Path:**
   - Copy the path of the `Logs` directory (`UnrealEditorFortnite\Saved\Logs`).

5. **Run UEListInvalid:**
   - Execute UEListInvalid and paste the copied log directory path when prompted.

6. **Review Output:**
   - UEListInvalid will process the log files, extract invalidated actor data, and save it in a file named `InvalidList.log` within an `Outputs` directory in the current working directory.

## Author
- ioan_123

### Notes:
- **Compatibility:** UEListInvalid is compatible with Unreal Engine projects that generate log files containing validation errors related to actors.
- **Customization:** For advanced users, consider modifying the regex pattern in the code (`\/Game\/[^\]]+`) to match specific validation error formats or criteria.
- **Feedback:** Your feedback is valuable! Please feel free to suggest improvements or report issues by contacting the author.

By following these steps, UEListInvalid empowers Unreal Engine developers to efficiently manage and address validation errors related to actors, enhancing project debugging and maintenance processes.
