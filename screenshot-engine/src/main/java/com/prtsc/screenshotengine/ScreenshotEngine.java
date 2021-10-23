package com.prtsc.screenshotengine;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import ru.yandex.qatools.ashot.AShot;

import javax.imageio.ImageIO;
import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

public class ScreenshotEngine {

    public static boolean takeScreenshot(String URL) {

        WebDriver webDriver = new ChromeDriver();
        webDriver.get(URL);
        var screenshot = new AShot()
                .takeScreenshot(webDriver);
        try {
            ImageIO.write(screenshot.getImage(), "PNG", new File("./Screenshots/" + new SimpleDateFormat("yyyyMMddHHmmss'.txt'").format(new Date()) + ".png"));
        } catch (Exception e) {
            System.out.println(e);
            return false;
        } finally {
            webDriver.quit();
            return true;
        }
    }
}
