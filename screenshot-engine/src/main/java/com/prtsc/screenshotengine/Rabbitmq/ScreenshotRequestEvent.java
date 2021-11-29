package com.prtsc.screenshotengine.Rabbitmq;

import com.google.gson.Gson;
import com.prtsc.screenshotengine.Helpers.ImageHelper;
import com.prtsc.screenshotengine.Models.ScreenshotCreated;
import com.prtsc.screenshotengine.ScreenshotEngine;
import com.prtsc.screenshotengine.Models.ScreenshotRequestModel;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

@Component
public class ScreenshotRequestEvent {
    Logger log = LoggerFactory.getLogger(ScreenshotRequestEvent.class);

    public void processScreenshotRequestMessage(String message) {
        Gson gson = new Gson();
        var request = gson.fromJson(message, ScreenshotRequestModel.class);

        var screenshot = ScreenshotEngine.takeScreenshot(request.getWebsiteURL());
        var stringImage = ImageHelper.transformImageToBase64String(screenshot);

        var sc = new ScreenshotCreated();
        sc.setImageBase64(stringImage);
        sc.setScreenshotId(request.getScreenshotId());

        EventPublisher.publishScreenshotToQueue(sc);
    }
}