package com.prtsc.screenshotengine;

import com.google.gson.Gson;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

import java.nio.charset.StandardCharsets;

@Component
public class EventReceiver {
    Logger log = LoggerFactory.getLogger(EventReceiver.class);

    public void receiveMessage(byte[] message) {
        String stringMessage = new String(message, StandardCharsets.UTF_8);
        Gson gson = new Gson();
        var request = gson.fromJson(stringMessage, ScreenshotRequestModel.class);
        ScreenshotEngine.takeScreenshot(request.getWebsiteURL());
    }

    public void receiveMessage(String message) {
        Gson gson = new Gson();
        var request = gson.fromJson(message, ScreenshotRequestModel.class);
        ScreenshotEngine.takeScreenshot(request.getWebsiteURL());
    }

}
