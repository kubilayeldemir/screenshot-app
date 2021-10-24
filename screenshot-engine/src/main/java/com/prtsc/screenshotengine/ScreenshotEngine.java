package com.prtsc.screenshotengine;

import com.prtsc.screenshotengine.Helpers.ImageHelper;
import com.prtsc.screenshotengine.Helpers.WebDriverHelper;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import ru.yandex.qatools.ashot.AShot;
import ru.yandex.qatools.ashot.Screenshot;

public class ScreenshotEngine {
    static Logger log = LoggerFactory.getLogger(ScreenshotEngine.class);

    @Autowired
    private ScreenshotEngine() {
    }

    public static Screenshot takeScreenshot(String URL) {
        var chromeDriver = WebDriverHelper.getChromeDriver();

        chromeDriver.get(URL);
        var screenshot = new AShot()
                .takeScreenshot(chromeDriver);
        log.info("New Screenshot captured: {}", URL);
        chromeDriver.get("data:,");

        return screenshot;
    }
}
