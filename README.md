# BuildCounter
Small tool for visual studio build counts/build dates

## How to use?
Copy tool to your code directory containing your solutions. Then in project options go to buildevents page and add:
call c:\path\buildcounter.exe $(ProjectDir) $(ProjectName)

In your project add created files (project.built) as resources and in your code call them:

  public static string BuildNumber
        {
            get
            {
                string build = GetResourceContent("projectname.count");
                build = build.Replace("\n", "");
                build = build.Replace("\r", "");
                return build;
            }
        }


        public static string BuildTime
        {
            get
            {
                string build = GetResourceContent("projectname.built");
                build = build.Replace("\n", "");
                build = build.Replace("\r", "");
                return build;
            }
        }
