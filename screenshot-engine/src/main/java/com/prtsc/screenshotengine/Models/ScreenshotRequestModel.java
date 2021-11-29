package com.prtsc.screenshotengine.Models;

public class ScreenshotRequestModel {
    private String ScreenshotId;

    private String WebsiteURL;

    public String getWebsiteURL() {
        return WebsiteURL;
    }

    public void setWebsiteURL(String websiteURL) {
        this.WebsiteURL = websiteURL;
    }

    public String getScreenshotId() {
        return ScreenshotId;
    }

    public void setScreenshotId(String screenshotId) {
        ScreenshotId = screenshotId;
    }
}
