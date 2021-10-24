package com.prtsc.screenshotengine.Helpers;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

public class WebDriverHelper {
    private static WebDriverHelper helper;
    private static WebDriver chromeDriver;

    private WebDriverHelper() {
        chromeDriver = new ChromeDriver();
    }

    private static void createInstanceIfNull() {
        if (helper == null) {
            helper = new WebDriverHelper();
        }
    }

    public static WebDriver getChromeDriver() {
        createInstanceIfNull();
        return chromeDriver;
    }
}
