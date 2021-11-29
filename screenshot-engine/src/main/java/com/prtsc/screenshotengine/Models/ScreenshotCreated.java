package com.prtsc.screenshotengine.Models;

public class ScreenshotCreated {
    private String ScreenshotId;

    public String imageBase64;

    public String getImageBase64() {
        return imageBase64;
    }

    public void setImageBase64(String imageBase64) {
        this.imageBase64 = imageBase64;
    }

    public String getScreenshotId() {
        return ScreenshotId;
    }

    public void setScreenshotId(String screenshotId) {
        ScreenshotId = screenshotId;
    }
}
