package com.prtsc.screenshotengine;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import ru.yandex.qatools.ashot.AShot;

import javax.imageio.ImageIO;
import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

public class ScreenshotEngine {
    static Logger log = LoggerFactory.getLogger(ScreenshotEngine.class);

    private ScreenshotEngine() {
    }

    public static boolean takeScreenshot(String URL) {
        var chromeDriver = WebDriverHelper.getChromeDriver();

        chromeDriver.get(URL);
        var screenshot = new AShot()
                .takeScreenshot(chromeDriver);
        try {
            ImageIO.write(screenshot.getImage(), "PNG", new File("./Screenshots/" + new SimpleDateFormat("yyyyMMddHHmmss'.txt'").format(new Date()) + ".png"));
            chromeDriver.get("data:,");
            log.info("New Screenshot captured: {}", URL);
            return true;
        } catch (Exception e) {
            log.error("Take Screenshot Error: {} ", e.getMessage());
            return false;
        }
    }
}
