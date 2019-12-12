if find $APPCENTER_SOURCE_DIRECTORY -name '*.UITest.csproj';
then
	echo "Building UI test projects:"
	find $APPCENTER_SOURCE_DIRECTORY -name '*.UITest.csproj' -exec msbuild {} \;
else
	echo "Can't find UI test project"
	exit 9999
fi
echo "Compiled projects to run UI tests:"
find $APPCENTER_SOURCE_DIRECTORY -regex '*.bin.*UITest.*\.dll' -exec echo {} \;
echo "Running test in App Center Test"
APPPATH=$APPCENTER_OUTPUT_DIRECTORY/*.apk
BUILDDIR=$APPCENTER_SOURCE_DIRECTORY/*.UITest/bin/Debug/
UITESTTOOL=$APPCENTER_SOURCE_DIRECTORY/packages/Xamarin.UITest.*/tools
appcenter test run uitest --app $APP_OWNER --devices $DEVICE_SET --test-series "$APPCENTER_BRANCH-$APPCENTER_TRIGGER" --locale $LOCALE --app-path $APPPATH --build-dir $BUILDDIR --async --uitest-tools-dir $UITESTTOOL --token $APPCENTER_TOKEN
